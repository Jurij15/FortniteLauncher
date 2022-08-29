#pragma once
#include "curl.h"
#include "url.h"

// Pick your poison
#define URL_HOST "localhost"
//#define URL_HOST "aurorafn.dev"

#define LOG_URLS

CURLcode(*curl_setopt)(struct Curl_easy*, CURLoption, va_list) = nullptr;
CURLcode(*curl_easy_setopt)(struct Curl_easy*, CURLoption, ...) = nullptr;

CURLcode curl_setopt_(struct Curl_easy* data, CURLoption option, ...) {
    va_list arg;
    va_start(arg, option);

    CURLcode result = curl_setopt(data, option, arg);

    va_end(arg);
    return result;
}

CURLcode curl_easy_setopt_detour(struct Curl_easy* data, CURLoption tag, ...) {
    va_list arg;
    va_start(arg, tag);

    CURLcode result;

    if (!data)
        return CURLE_BAD_FUNCTION_ARGUMENT;

    if (tag == CURLOPT_SSL_VERIFYPEER) {
        result = curl_setopt_(data, tag, 0);
    }
    else if (tag == CURLOPT_URL) {
        char* url = va_arg(arg, char*);
        if (!memcmp(url, "https", 5)) {
            url[1] = 'h';
            url[2] = 't';
            url[3] = 't';
            url[4] = 'p';
            url++;
        }
        printf("URL: %s\n", url);
        result = curl_setopt_(data, CURLOPT_SSL_VERIFYPEER, 0);
        result = curl_setopt_(data, tag, url);
    }
#ifdef URL_HOST
    else if (tag == CURLOPT_URL) {
        /*
        std::string url = va_arg(arg, char*);
        size_t length = url.length();

        Uri uri = Uri::Parse(url);
        if (uri.Host.ends_with(".ol.epicgames.com")) {
            url = Uri::CreateUri("http", URL_HOST, "3551", "localhost", uri.QueryString);
        }
        if (url.length() < length) {
            url.append(length - url.length(), ' '); // buffer size checking can occur
        }
        */
        std::string url = va_arg(arg, char*);
        size_t length = url.length();
        Uri uri = Uri::Parse(url);

        if (uri.Host.ends_with(("ol.epicgames.com")) || uri.Host.ends_with((".akamaized.net")) || uri.Host.ends_with(("on.epicgames.com")))
        {
            //printf("LogURL: %s\n", url.c_str());
            url = Uri::CreateUri("http", URL_HOST, "3551", uri.Path, uri.QueryString);
        }

#ifdef LOG_URLS
        printf("Url logged: %s\n", tag, url.c_str());
#endif

        result = curl_setopt_(data, tag, url.c_str());
    }
#endif
    else {
        result = curl_setopt(data, tag, arg);
    }

    va_end(arg);
    return result;
}
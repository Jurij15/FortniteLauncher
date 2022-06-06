# FortniteLauncher
A simple launcher for LawinServer, made in C# with ModernWPF

If you encounter any issues, scroll down to Troubleshooting section

# Full tutorial
- video here after done

# Setup
## Prerequisites
- Download and install [NodeJS](https://nodejs.org/en/download/)
- Download and install [.NET 6 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Download and install [Fiddler Classic](https://www.telerik.com/download/fiddler)
- Have a Fortnite Version you want to use (can be any) [Download S0-S7 Here!](https://github.com/notsamicc/Fortnite-Builds)))
## Proxy setup
Even though proxy is included in the launcher, it can cause issues. I recommend using Fiddler.
### Fiddler setup
- Video: tbd
- Make sure you have installed Fiddler from the above link,
- Open Fiddler and click on the FiddlerScript tab
- Delete everything that is there and paste this script in:
```
import System;
import System.Web;
import System.Windows.Forms;
import Fiddler;

class Handlers
{ 
    static function OnBeforeRequest(oSession: Session) {
        if (oSession.hostname.Contains("ol.epicgames.com")) {
            if (oSession.HTTPMethodIs("CONNECT"))
            {
                oSession["x-replywithtunnel"] = "FortniteTunnel";
                return;
            }
            oSession.fullUrl = "http://localhost:3551" + oSession.PathAndQuery;
        }
    }
}
```
- Go to Tools>Options
- Click on the HTTPS tab
- Check `Capture HTTPS CONNECTs` and `Decrypt HTTPS CONNECTs`
- Click `Actions`>`Trust Root Certificate`
- Click YES on all dialogs that show up
- Close Options
- You're now ready to use LawinServer

## Installing
- Download the latest one in Releases and extract it
- Video : tbd

## Compiling
- Download source or clone
- Compile with .NET 6

# Troubleshooting
## Launcher issues
- Make sure you installed .NET 6.0 from above link
###Common issues
#### Launcher or proxy is not starting or closes after started
- Make sure you installed .NET 6.0 from above link


## LawinServer issues
- Join [Lawin's Discord](https://discord.gg/AtXKh4rZCt) and look in channel #faq-and-troubleshooting
### Common issues:
#### My internet is not working after using LawinServer
- Disable proxy in Windows settings
- Video in Lawin's discord
### Fortnite is showing `Unable to login to Fortnite servers`
- Restart the launcher
- Use Fiddler instead of the built-in proxy

# Credits
- [Lawin - LawinServer](https://github.com/Lawin0129/LawinServer) [Lawin's Discord](https://discord.gg/AtXKh4rZCt)
- [PsychoPast- Proxy](https://github.com/PsychoPast/LawinServer)
- Nyamimi - SSL Bypass (Aurora.Runtime)
- [SSL Injection](https://github.com/Londiuh/FortniteLauncher)

# Contact
- Jurij15#1867 on Discord

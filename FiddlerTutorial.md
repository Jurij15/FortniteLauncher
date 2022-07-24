# Fiddler setup
-Download and install [Fiddler Classic](https://www.telerik.com/download/fiddler)
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

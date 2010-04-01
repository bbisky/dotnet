//Basic Ajax Routine- Author: Dynamic Drive (http://www.dynamicdrive.com)
//Last updated: Jan 15th, 06'
//http://www.dynamicdrive.com/dynamicindex17/ajaxroutine.htm
function ajax()
{
    //var basedomain="http://"+window.location.hostname
    //var soapPost = "";
    var host = window.location.hostname;
    var ajaxobj=createAjaxObj()
    var filetype="txt"
    var addrandomnumber=1 //Set to 1 or 0. See documentation.
    var result;
    var url;
    this.getRequest = getMyAjaxRequest;
    this.postRequest = postMyAjaxRequest;
    this.soapRequest = soapMyAjaxRequest;
    this.getResponse = getMyResponse;
    this.callbackfunction;
    
    function getMyAjaxRequest(url, parameters, callbackfun,filetype)
    {
        this.url = url;
        ajaxobj=createAjaxObj() //recreate ajax object to defeat cache problem in IE
        if (addrandomnumber==1) //Further defeat caching problem in IE?
            var parameters=parameters+"&ajaxcachebust="+new Date().getTime()
        if (ajaxobj)
        {            
            callbackfunction = callbackfun;
            ajaxobj.onreadystatechange=this.getResponse;
            ajaxobj.open('GET', url+"?"+parameters, true);
            ajaxobj.send(null);
        }
    }
    function postMyAjaxRequest(url, parameters, callbackfun, filetype)
    {
        ajaxobj=createAjaxObj() //recreate ajax object to defeat cache problem in IE
        if (ajaxobj)
        {
           ajaxobj.onreadystatechange = this.getResponse;
           callbackfunction = callbackfun;
            ajaxobj.open('POST', url, true);
            ajaxobj.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            ajaxobj.setRequestHeader("Content-length", parameters.length);
            ajaxobj.setRequestHeader("Connection", "close");
            ajaxobj.send(parameters);
        }
    }
    
    function soapMyAjaxRequest(url, parameters, callbackfun)
    {
        ajaxobj=createAjaxObj() //recreate ajax object to defeat cache problem in IE
        if (ajaxobj)
        {
            ajaxobj.onreadystatechange = getSoapResponse;
            callbackfunction = callbackfun;
            ajaxobj.open('POST', url, true);
            ajaxobj.setRequestHeader("Man", "POST " + url + " HTTP/1.1");
            ajaxobj.setRequestHeader("Host", host);
            ajaxobj.setRequestHeader("Content-Type", "application/soap+xml; charset=utf-8");
            ajaxobj.setRequestHeader("Content-length", parameters.length); 
            ajaxobj.send(parameters);
        }
    }
    
    function getSoapResponse()
    {
	    var myajax = ajaxobj;
	    var myfiletype = filetype;
	    if (myajax.readyState == 4) 
	    {
	        callbackfunction(myajax.responseText);
	    }

    }
    function getMyResponse()
    {
	    var myajax = ajaxobj;
	    var myfiletype = filetype;
	    if (myajax.readyState == 4) 
		    if (myajax.status==200 || window.location.href.indexOf("http")==-1)
		    {    
			    result = myajax.responseText;
			    callbackfunction(result)
			 }

    }
}

function createAjaxObj()
{
    var xmlhttp=false;
    /*@cc_on @*/
    /*@if (@_jscript_version >= 5)
    // JScript gives us Conditional compilation, we can cope with old IE versions.
    // and security blocked creation of the objects.
     try {
      xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
     } catch (e) {
      try {
       xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
      } catch (E) {
       xmlhttp = false;
      }
     }
    @end @*/
    if (!xmlhttp && typeof XMLHttpRequest!='undefined') 
    {
        try 
        {
            xmlhttp = new XMLHttpRequest();
        } 
        catch (e) 
        {
            xmlhttp=false;
        }
    }
    if (!xmlhttp && window.createRequest) 
    {
        try 
        {
        xmlhttp = window.createRequest();
        } 
        catch (e) 
        {
            xmlhttp=false;
        }
    }
    return xmlhttp
}


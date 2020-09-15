export function setCookie(cname,cvalue,exhours)
{
  var d = new Date();
  d.setTime(d.getTime()+(exhours*60*1000));
  var expires = "expires="+d.toGMTString();
  document.cookie = cname + "=" + cvalue + "; " + expires;
}

export function getCookie(cname)
{
  var name = cname + "=";
  var ca = document.cookie.split(';');
  for(var i=0; i<ca.length; i++) 
  {
    var c = ca[i].trim();
    if (c.indexOf(name)==0) return c.substring(name.length,c.length);
  }
  return "";
}

export function checkCookie(cookieName)
{
  var cookieValue = getCookie(cookieName);
  if (cookieValue!="")
  {
    return cookieValue
  }
  else 
  {
    return ''
  }
}
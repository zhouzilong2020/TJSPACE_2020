export const URL = "http://175.24.115.240:8080/api/"
export const token = 'Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjkzNTMwMzY3ZDI0OTFiMzQ0MTEzODYwZGUyN2QzNzdlIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1OTk5OTYyMTYsImV4cCI6MTU5OTk5OTgxNiwiaXNzIjoiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAiLCJhdWQiOlsiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAvcmVzb3VyY2VzIiwiYXBpMSJdLCJjbGllbnRfaWQiOiJjbGllbnQyIiwic3ViIjoiMTExIiwiYXV0aF90aW1lIjoxNTk5OTk2MjE2LCJpZHAiOiJsb2NhbCIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJhcGkxIl0sImFtciI6WyJjdXN0b20iXX0.VukSTIp_42uMXaYUb2yJs1nUu0yMnUC8A9mtRSVpsqpiQC6KGDmb7UuxBCXAx8m5-lhpVSAR5EMdX82QEqsD7znpK4VKzXlamCiGnuV-4bJkHsB1pB0rSfjD5UhSthxEib6KcQ2AOIdjWNBLzFgF-xxnQL_iUFxD_YoikfcvXIgah23dsMa50Z5J4ueFabJw4lRuNGaPBF9pn8W67tNLQPu9GNdoE9YW-cJUS9fJJvOgpJFIxzsuB9QZk-nED_42GLByAP6tmQ2BbAYSmuWDPTblkhalZmXz3xgCdcY_HEtISC2LxjUO67y35MwTaefxL1CWl26belyJwOhyEM6o9w'

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

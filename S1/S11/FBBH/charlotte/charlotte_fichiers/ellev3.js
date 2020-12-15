<!--
if (CM_CLIENT=='') alert("Please fill in the CM_CLIENT variable in your HTML code");
cm_arg = "http://stat3.cybermonitor.com/"+CM_CLIENT+"_v?R="+CM_RUBRIQUE+"&S=total;";
if(CM_SECTION1) cm_arg+=CM_SECTION1;
cm_arg+="&RF="+escape(document.referrer)+"&A="+escape(Math.random());
cm_i = new Image(1,1);
cm_i.src = cm_arg;
// -->

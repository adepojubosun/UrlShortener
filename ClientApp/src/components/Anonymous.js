import React, { useEffect } from "react";

const scheme = window.location.href.split("/")[0]+"//";

export const Anonymous = ({ match }) => {
  useEffect(() => {
    let uniqueId = match.params.id;
    fetch("/api/url/retrieve/" + uniqueId)
      .then(res => {
        return res.json();
      })
      .then(data => {
       let fLongUrl = data.longUrl;
       if(!fLongUrl.startsWith("http"))
       {
         fLongUrl = scheme+fLongUrl;
       }
        window.open(fLongUrl, "_self");
      });
  });

  return <div></div>;
};

"use strict";

let R = null;

let b1 = document.querySelector( "#b1" );

async function loadd()
{
    //fetch()
    let url = `https://juxinglong.github.io/static/data/states.json`;

   let r =await fetch(url);
    let rj = awair r.json();


    Swal.fire("Load data");
}

b1.addEventListener("click", loadd);
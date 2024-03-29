"use strict";

let R = null;

let b1 = document.querySelector( "#b1" );
let cahrt1 = null;

async function loadd()
{
    //fetch()
    let url = `https://juxinglong.github.io/static/data/states.json`;

   let r =await fetch(url);
   let rj = await r.json();

    let c1 = document.querySelector("#c1");
    if (chart1 != null)
    {
        chart1.destroy();
    }
    c1.innerHTML = ``;

    let opts = {
        type: "pie",
       
        data: {
            labels: rj.map(x => x.st),
            datasets: [
                {data:rj.map(x=>x.p), },
            ],
        },
    };
    chart1 = new Chart(c1, opts);

    R = rj;
    console.log(rj);

    Swal.fire("Load data");
}

b1.addEventListener("click", loadd);
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
//const formSubmitted = function (e) {
//    e.preventDefault();
//    let value = this.elements["rowValueNumber"].value;
//    let polygonElement = document.getElementById("rowGraph");

//    polygonElement.points.clear();

//    let point1 = polygonElement.parentElement.createSVGPoint();
//    point1.x = 0;
//    point1.y = 0;
//    console.log(point1);
//    polygonElement.points.appendItem(point1);

//    let point2 = polygonElement.parentElement.createSVGPoint();
//    point2.x = value * 8;
//    point2.y = 0;
//    console.log(point2);
//    polygonElement.points.appendItem(point2);

//    let point3 = polygonElement.parentElement.createSVGPoint();
//    point3.x = value * 8;
//    point3.y = 50;
//    console.log(point3);
//    polygonElement.points.appendItem(point3);

//    let point4 = polygonElement.parentElement.createSVGPoint();
//    point4.x = -300;
//    point4.y = 50;
//    console.log(point4);
//    polygonElement.points.appendItem(point4);

//    let width = polygonElement.viewBox;
//    console.log(width);

//}

//const init = function () {

//    let form = document.getElementById("graphForm");
//    let posuvnik = document.getElementById("rowValue");
//    let rowValueNumber = document.getElementById("rowValueNumber");


//    if (searchParams.has("val")) {
//        posuvnik.value = searchParams.get("val");
//        rowValueNumber.value = searchParams.get("val");
//    }


//    form.addEventListener("submit", formSubmitted);
//    posuvnik.addEventListener("change", (e) => {
//        rowValueNumber.value = posuvnik.value;
//    });
//}
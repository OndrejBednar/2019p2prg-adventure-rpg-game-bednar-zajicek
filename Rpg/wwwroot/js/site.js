// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function openInventory()
{
    document.getElementsByClassName("inventory")[0].style.display = "flex";

}

function closeInventory() {
    document.getElementsByClassName("inventory")[0].style.display = "none";
}
function itemClick() {
    let statDesc = this.nextElementSibling;
    let button = statDesc.nextElementSibling;
    
    let invUseImg = document.querySelector(".inventory-use img");
    let invUseP = document.querySelector(".inventory-use p");
    let invUseButton = document.querySelector(".inventory-use a");

    invUseButton.classList.add("btn", "btn-primary");
    invUseButton.href = button.href;
    invUseButton.innerHTML = button.innerHTML;

    invUseImg.src = this.src;
    invUseP.style.color = "whitesmoke";
    invUseP.innerHTML = statDesc.innerHTML;
}

window.addEventListener("DOMContentLoaded", () => {
    document.getElementById("Inventory").addEventListener("click", openInventory)
    document.getElementsByClassName("close")[0].addEventListener("click", closeInventory);  

    items = document.querySelectorAll(".item img");
    for (const i of items) {
        i.addEventListener("click", itemClick)
    }
})
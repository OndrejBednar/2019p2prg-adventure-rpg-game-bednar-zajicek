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
function openSpells() {
    document.getElementsByClassName("spellbook")[0].style.display = "flex";

}

function closeSpells() {
    document.getElementsByClassName("spellbook")[0].style.display = "none";
}
function itemClick() {
    let statDesc = this.children[1];
    let Desc = statDesc.nextElementSibling;
    let button = Desc.nextElementSibling;
    
    let invUseDiv = document.querySelector(".inventory-use");
    let invUseImg = document.querySelector(".inventory-use img");
    let invUseH4 = document.querySelector(".inventory-use h4");
    let invUseP = document.querySelector(".inventory-use p");
    let invUseButton = document.querySelector(".inventory-use a");

    invUseButton.classList.add("btn", "btn-primary");
    invUseButton.href = button.href;
    invUseButton.innerHTML = button.innerHTML;

    invUseDiv.style.display = "block";

    invUseImg.src = this.children[0].src;

    invUseP.style.color = "whitesmoke";
    invUseP.innerHTML = Desc.innerHTML;

    invUseH4.style.color = "whitesmoke";
    invUseH4.innerHTML = statDesc.innerHTML;
}

window.addEventListener("DOMContentLoaded", () => {
    document.getElementById("Inventory").addEventListener("click", openInventory);
    document.getElementsByClassName("close")[0].addEventListener("click", closeInventory);
    items = document.querySelectorAll(".item");
    for (const i of items) {
        i.addEventListener("click", itemClick)
    }

    document.getElementById("Spells").addEventListener("click", openSpells);
    document.getElementsByClassName("close")[1].addEventListener("click", closeSpells);  

})
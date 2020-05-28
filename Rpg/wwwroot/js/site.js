// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function openInventory()
{
    document.getElementsByClassName("inventory")[0].style.display = "flex";
    console.log("ss");
}

function closeInventory() {
    document.getElementsByClassName("inventory")[0].style.display = "none";
}

window.addEventListener("DOMContentLoaded", () => {
    document.getElementById("Inventory").addEventListener("click", openInventory)
    document.getElementsByClassName("close")[0].addEventListener("click", closeInventory);
})
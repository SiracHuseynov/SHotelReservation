document.addEventListener("DOMContentLoaded", function () {
    var currentPath = window.location.pathname

    var menuLinks = document.querySelectorAll(".menu-list a")

    menuLinks.forEach(function (item) {
        if (item.getAttribute("href") === currentPath) {
            item.closest(".menu-list").classList.add("current-menu-item")
        }

    })
})




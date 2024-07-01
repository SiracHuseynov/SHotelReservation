let addTobBasketBtns = document.querySelectorAll(".add-to-basket")


addTobBasketBtns.forEach(btn => btn.addEventListener("click", function (e) {


    let url = btn.getAttribute("href");

    if (document.getElementById("arrive").value && document.getElementById("departure").value)
        url = url + "&arrive=" + document.getElementById("arrive").value + "&departure=" + document.getElementById("departure").value
    else {
        alert("Arrive ve departure date secin")
    }


    e.preventDefault();

    if (document.getElementById("arrive").value && document.getElementById("departure").value) {
        fetch(url)
            .then(response => {
                if (response.status == 200) {
                    alert("Added to basket") 
                }
                else {
                    alert("Rezerv var!")
                }
            })
    }

}))


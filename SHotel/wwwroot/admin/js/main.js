﻿let deleteBtns = document.querySelectorAll(".btn-delete")

deleteBtns.forEach(btn => {
    btn.addEventListener("click", function (e) {

        let url = btn.getAttribute("href")

        e.preventDefault();
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(url)
                    .then(response => {
                        if (response.status == 200) {
                            window.location.reload(true);
                        }
                        else {
                            alert("Silinmedi")
                        }
                    })
            }
        });

    })
})
////LoadMore

let skip = 3;
let roomCount = $("#roomCount").val();

$(document).on("click", "#LoadMoreBtn", function () {
    $.ajax({
        method: "get",
        url: "/home/loadmore?skip=" + skip,
        success: function (data) {
            skip += 3;
            $("#roomList").append(data);
            if (skip >= roomCount) {
                $("#LoadMoreBtn").remove();
            }

        }
    })
});
function main() {
    $(".table-row:even").on("click", function () {
        $(this).toggleClass("highlighted");
    });

    $(".table-row:odd").on("click", function () {
        $(this).toggleClass("oddrow");
        $(this).toggleClass("highlighted");
    });

    $(".table-row:even").hover(function () {
        $(this).toggleClass("hovered");
    });

    $(".table-row:odd").hover(function () {
        $(this).toggleClass("oddrow");
        $(this).toggleClass("hovered");
    });
    
    $('#button').on("click", function () {
        var idList = new Array();
        $(".highlighted td:first-child").each(function () {
            idList.push($(this).text());
        });
        $.ajax({
            type: "GET",
            url: "/Admin/Delete",
            data: { values: idList },
            success: function (data) {
                alert(data.Result);
            },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            traditional: true
        });
        $(".highlighted").each(function () {
            $(this).remove();
        });
    });

    $(".table-row:odd").addClass("oddrow");
}
$(document).ready(main);
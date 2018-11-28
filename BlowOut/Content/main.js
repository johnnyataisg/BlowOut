function main() {
    $(".table-row:even").on("click", function () {
        $(this).toggleClass("highlighted");
    });

    $(".table-row:odd").on("click", function () {
        $(this).toggleClass("oddrow");
        $(this).toggleClass("highlighted");
    });

    $('#button').on("click", function () {
        $(".highlighted td:first-child").each(function () {
            alert($(this).text());
        });
    });

    $(".table-row:odd").addClass("oddrow");
}
$(document).ready(main);
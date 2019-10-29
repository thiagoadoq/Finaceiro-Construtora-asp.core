[].forEach.call(document.getElementsByClassName('mvc-grid'), function (element) {
    new MvcGrid(element);
});

$('#grid-search').focus();

$(document).on('keyup', '.grid-search', function () {
    var grid = $('.mvc-grid').data('mvc-grid');
    grid.query = 'search=' + this.value; // Reset page, filter and sort with new filter.

    $('.mvc-grid').mvcgrid({
        reload: true
    });
});

$('.content-refresh').on('click', function () {
    $('.mvc-grid').mvcgrid({
        reload: true
    });
});
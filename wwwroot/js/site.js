// Write your Javascript code.

$.expr[":"].contains = $.expr.createPseudo(function(arg) {
    return function( elem ) {
        return $(elem).text().toUpperCase().indexOf(arg.toUpperCase()) >= 0;
    };
});

$( "#search" ).keyup(function() {
    $('.podcastWrapper').show();
    var searchText = $(this).val();

    $('.podcastName:not(:contains('+ searchText +'))').parent().parent().hide();

    $('.tagSpan:contains('+ searchText +')').parent().parent().show();

    // $('.tagSpan:contains('+ searchText +')').show();
});

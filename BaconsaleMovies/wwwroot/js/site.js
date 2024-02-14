$('#submitMovie').on('submit', function () {
    $('#SubmitMovie').filter(':input').each((_, input) => {
        input.val(null);
    });
    return true;
});
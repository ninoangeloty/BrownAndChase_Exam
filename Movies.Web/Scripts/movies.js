$(document).ready(function () {
    $(document).on('click', '#add-list-box', addToList);
    $(document).on('click', '#btnsubmit', submit);
    $(document).on('click', '#btncancel', cancel);
    $(document).on('keydown', '#Cast', listBoxKeyDown)
    initialize();
});

function addToList() {
    var text = $('#text-list-box').val();
    $('#text-list-box').val('');
    $('#Cast').append('<option value="' + text + '">' + text + '</option>');
}

function initialize() {
    // $("#ReleaseDate").datepicker();
}

function submit(e) {
    e.preventDefault();

    $('#Cast > option').prop("selected", true);
    $('form').submit();
}

function cancel() {
    window.location = '/Home';
}

function listBoxKeyDown(e) {
    if (e.keyCode == 46) {
        $('#Cast option:selected').remove();
    }
}
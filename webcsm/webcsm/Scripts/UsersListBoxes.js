
function add() {
    $("#AvailableUsers option:selected").appendTo("#SelectedUsers");
}

function addall() {
    $("#AvailableUsers option").appendTo("#SelectedUsers");
}

function remove() {
    $("#SelectedUsers option:selected").appendTo("#AvailableUsers");
}

function removeall() {
    $("#SelectedUsers option").appendTo("#AvailableUsers");
}


function MascaraCpf(input, event) {
    if ((event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode >= 48 && event.keyCode <= 57)) {
        if (input.value.length == 3 || input.value.length == 7) {
            input.value = input.value + '.';
        }
        if (input.value.length == 11) {
            input.value = input.value + '-';
        }
    }
}

function MascaraData(input, event) {
    if ((event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode >= 48 && event.keyCode <= 57)) {
        if (input.value.length == 2 || input.value.length == 5) {
            input.value = input.value + '/';
        }
    }
}
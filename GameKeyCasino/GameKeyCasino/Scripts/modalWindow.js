function closeModalWindow(modalWindowId) {
    let modal = document.getElementById(modalWindowId);
    modal.style.display = "none";
}

function openModalWindow(modalWindowId) {
    let modal = document.getElementById(modalWindowId);
    modal.style.display = "block";
}

function openModalWindowWithData(modalWindowId, dataInputId, inputValue) {
    let dataInput = document.getElementById(dataInputId);
    dataInput.value = inputValue;
    let modal = document.getElementById(modalWindowId);
    modal.style.display = "block";
}
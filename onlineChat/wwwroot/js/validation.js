function setVailidation(data, idInputs) {
    idInputs.forEach(item => {
        let temp = data.ValidationMessage[item];
        let element = document.getElementById(item);

        if (temp != undefined) {

            setValidationInElement(element, "is-invalid", data.ValidationMessage[item]);
        }
        else {
            setValidationInElement(element, "is-valid", "");
        }
    });
}

function setValidationInElement(element, cssClass, text) {
    element.classList.remove("is-valid");
    element.classList.remove("is-invalid");
    element.classList.add(cssClass);
    element.closest(".form-group").querySelector(".invalid-feedback").innerHTML = text;
}
function getIdInput(parentSelector, childrenSelector) {
    let parentElement = document.querySelector(parentSelector)
    let elements = parentElement.querySelectorAll(childrenSelector);
    return elements;
}
function clearValid(element) {
    element.classList.remove("is-valid");
    element.classList.remove("is-invalid");
    element.closest(".form-group").querySelector(".invalid-feedback").innerHTML = "";
}
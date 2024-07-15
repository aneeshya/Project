function validateNameInput(input) {
    // Allow only letters and spaces
    const regex = /^[a-zA-Z\s]*$/;
    if (!regex.test(input.value)) {
        input.value = input.value.replace(/[^a-zA-Z\s]/g, '');
        alert("Please enter only alphabetic characters and spaces.");
    }
}

module.exports = {
    isTwelveDigits: (num) => {
        return /^\d{10}$/.test(num);
    }
}
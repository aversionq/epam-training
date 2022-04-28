function mathCalculator(mathExpression) {
    const mathOperators = ["+", "-", "*", "/"];
    let operatorsPos = [];
    let digits = [];

    digits = mathExpression.replace("=", "").split(/[\+\-\*\/]/).map(Number);
    
    for (var item of mathExpression.split("")) {
        if (mathOperators.includes(item)) {
            operatorsPos.push(item);
        }
    }

    let result = digits[0];

    operatorsPos.forEach((operator, index) => {
        switch (operator) {
            case "*":
                result *= digits[index + 1];
                break;
            case "/":
                result /= digits[index + 1];
                break;
            case "+":
                result += digits[index + 1];
                break;
            case "-":
                result -= digits[index + 1];
                break;
            default:
                break;
        }
    });

    return result.toFixed(2)
}

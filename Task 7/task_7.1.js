function char_remover(str) {
    let splittedStr = str.split(" ")
    let charsToRemove = []

    for (let i = 0; i < splittedStr.length; i++) {
        let setStr = new Set(splittedStr[i])

        for (let item of setStr) {
            let charCount = 0
            console.log(item)
            for (let k = 0; k < splittedStr[i].length; k++) {
                if (splittedStr[i][k] == item) {
                    charCount++
                }
            }

            if (charCount > 1) {
                charsToRemove.push(item)
            }
        }

    }

    for (let char of charsToRemove) {
        for (let i = 0; i < splittedStr.length; i++) {
            splittedStr[i] = splittedStr[i].replaceAll(char, "")
        }
    }

    return splittedStr.join(" ")
}

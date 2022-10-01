// Example1

// removeBlanks(" Pl ayTha tF u nkyM usi c ") => "PlayThatFunkyMusic"
// removeBlanks("I can not BELIEVE it's not BUTTER") => "IcannotBELIEVEit'snotBUTTER"

function removeBlanks(str){
    let newBlank= ''

    for (let i = 0; i < str.length; i++) {
        if (str[i] != ' ') {
            newBlank += str[i];
        }
    }
    return newBlank
}
console.log(removeBlanks(" Pl ayTha tF u nkyM usi c "))
console.log(removeBlanks("I can not BELIEVE it's not BUTTER"))



// Example2:

// getDigits("abc8c0d1ngd0j0!8") => 801008

// getDigits("0s1a3y5w7h9a2t4?6!8?0") => 1357924680

function getDigits(str){
    let newnumberstring = ''
    for(let char in str){
        if(!isNaN(str[char])){
            newnumberstring += str[char]
        }
    }
    return Number(newnumberstring)
}
console.log(getDigits("abc8c0d1ngd0j0!8"))
console.log(getDigits("0s1a3y5w7h9a2t4?6!8?0"))



// example3
// acronym(" there's no free lunch - gotta pay yer way. ") => "TNFL-GPYW". 
// acronym("Live from New York, it's Saturday Night!") => "LFNYISN".

function acronym (str){
    let wordsArr = str.split(' ')
    let acronymStr = ''

    for (let word in wordsArr) {
      if (wordsArr[word].length > 0) {
         acronymStr += wordsArr[word][0].toUpperCase()
      }   
    }
    return acronymStr
}
console.log(acronym(" there's no free lunch - gotta pay yer way. "))
console.log(acronym("Live from New York, it's Saturday Night!"))




// Example4:
// countNonSpaces("Honey pie, you are driving me crazy") => 29
// countNonSpaces("Hello world !") => 11


function countNonSpaces(str){
    let counter = 0
    for (let char in str) {
       if(str[char] != ' '){
        counter++
       }
    }
    return counter
}
console.log(countNonSpaces("Honey pie, you are driving me crazy"))
console.log(countNonSpaces("Hello world !"))


// Examples5:

// removeShorterStrings(['Good morning', 'sunshine', 'the', 'Earth', 'says', 'hello'], 4) => ['Good morning', 'sunshine', 'Earth', 'says', 'hello']
// removeShorterStrings(['There', 'is', 'a', 'bug', 'in', 'the', 'system'], 3) => ['There', 'bug', 'the', 'system']



function removeShorterStrings(arr, len) {
    let newStrings = []
    let nextIndex = 0

    for (let value in arr){
        if(arr[value].length >= len){
        newStrings[nextIndex] = arr[value]
        nextIndex++
        }
    }
    return newStrings
}
console.log(removeShorterStrings(['Good morning', 'sunshine', 'the', 'Earth', 'says', 'hello'], 4))
console.log(removeShorterStrings(['There', 'is', 'a', 'bug', 'in', 'the', 'system'], 3))
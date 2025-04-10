export class StringProcess {

    public static processString(rule: string, input: string, repeat: number = 1): string {
        let array = rule.match(/-[a-z]+/g);
        if (array == null) {
            console.error("processString error invalid: " + rule);
        }

        let e: string = array[0];
        e = e.substring(1, e.length);

        let length = e.length;
        for (let i = 0; i < length; i++) {
            let suffix = e.charAt(i);
            let funKey = "_processStringWith" + suffix.toUpperCase();
            if (StringProcess[funKey]) {
                input = StringProcess[funKey](input, repeat);
            }
            else {
                console.error("processString error invalid rule: " + rule);
            }
        }

        return input;
    }

    /*
       -o: Original form without any processing
   */
    private static _processStringWithO(input: string): string {
        return input;
    }

    //-l: Lowercase the first letter
    private static _processStringWithL(input: string): string {
        let first = input.charAt(0);
        first = first.toLowerCase();
        return first + input.substring(1, input.length);
    }

    //-m: Convert all letters to uppercase
    private static _processStringWithM(input: string): string {
        return input.toUpperCase();
    }

    //-u: Uppercase the first letter
    private static _processStringWithU(input: string): string {
        let first = input.charAt(0);
        first = first.toUpperCase();
        return first + input.substring(1, input.length);
    }

    //-v: Convert all letters to uppercase
    private static _processStringWithV(input: string): string {
        return input.toUpperCase();
    }

    //-r: Remove the first letter
    private static _processStringWithR(input: string): string {
        return input.substring(1, input.length);
    }

    //-t: Remove all underscores and capitalize the first letter after each underscore. e.g., error_code => errorCode
    private static _processStringWithT(input: string): string {
        let array = input.split("_");
        for (let i = 1; i < array.length; i++) {
            array[i] = this._processStringWithU(array[i]);
        }

        return array.join("");
    }

    //-n: Append a suffix, e.g., joinChannel2
    private static _processStringWithN(input: string, repeat: number = 1): string {
        if (repeat < 2) {
            return input;
        }
        else {
            return input + repeat;
        }
    }

    //-s: Remove namespace from the name
    private static _processStringWithS(input: string, repeat: number = 1): string {
        let array = input.split("::");
        if (array && array.length > 1) {
            return array[array.length - 1];
        }
        return input;
    }

    //-c: Remove &, *, spaces, etc. from the string and capitalize letters
    private static _processStringWithC(input: string, repeat: number = 1): string {
        let length = input.length;
        let up: boolean = false;
        let r: string[] = [];
        for (let i = 0; i < length; i++) {
            let e = input.charAt(i);
            if (e != "&" && e != "*" && e != " " && e != "<" && e != ">") {
                if (up) {
                    e = e.toUpperCase();
                    up = false;
                }
                r.push(e);
            }
            else {
                up = true;
            }
        }
        return r.join('');
    }

    //-y: Remove all spaces and capitalize the first letter after each space. e.g., err code => errCode
    private static _processStringWithY(input: string, repeat: number = 1): string {

        let array = input.split(" ");
        for (let i = 1; i < array.length; i++) {
            array[i] = this._processStringWithU(array[i]);
        }

        return array.join("");

    }

    //-p: Remove the last character of the text
    private static _processStringWithP(input: string, repeat: number = 1): string {
        return input.substring(0, input.length - 1);
    }

    //-e: Add an equals sign at the beginning of the string if it's not empty
    private static _processStringWithE(input: string, repeat: number = 1): string {
        if (input != null && input != "") {
            return "=" + input;
        }
        return input;
    }

    //-f: Remove 'ref ' from the beginning
    private static _processStringWithF(input: string, repeat: number = 1): string {
        if (input.startsWith("ref ")) {
            return input.substring(4, input.length);
        }
        else {
            return input;
        }
    }

    //-a: Remove '@' from the beginning
    private static _processStringWithA(input: string, repeat: number = 1): string {
        if (input.startsWith("@")) {
            return input.substring(1, input.length);
        }
        else {
            return input;
        }
    }
}


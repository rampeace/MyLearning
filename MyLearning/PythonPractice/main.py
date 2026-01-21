"""Entry point for sample runs."""

def reverse_vowels(s:str):
    vowels = set("aeiou")

    left = 0
    right = len(s) - 1

    chars = list(s)

    while(left < right):
        if s[left] not in vowels:
            left += 1
            continue
        if s[right] not in vowels:
            right -= 1
            continue
        
        temp = chars[left]
        chars[left] = chars[right]
        chars[right] = temp

        left += 1
        right -= 1

    return str(chars)

s = "eliephanot"

print(reverse_vowels(s))


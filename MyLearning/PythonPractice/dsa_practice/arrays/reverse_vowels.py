"""Reverse vowels in a string."""

# C# ReverseVowels.ReverseVowelsOfAString

def reverse_vowels_of_a_string(s):
    """Return a string with vowels reversed.

    Problem: Reverse only the vowels in the input string.
    Approach: Two pointers with a vowel set to swap vowels in-place.
    Time complexity: O(n)
    Space complexity: O(n)
    """
    if s is None:
        return None

    left = 0
    right = len(s) - 1
    chars = list(s)
    vowels = set("AEIOUaeiou")

    while left < right:
        if chars[left] not in vowels:
            left += 1   
        elif chars[right] not in vowels:
            right -= 1
        else:
            chars[left], chars[right] = chars[right], chars[left]
            left += 1
            right -= 1

    return "".join(chars)


# C# ReverseVowels.Test

def reverse_vowels_test():
    """Run the sample input from the C# Test method and return the result."""
    s = "leetcode"
    return reverse_vowels_of_a_string(s)

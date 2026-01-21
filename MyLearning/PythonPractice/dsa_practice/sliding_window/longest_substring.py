"""Longest substring utilities."""

# C# LongestSubstring.LongestSubstringWithoutRepeatingCharacters

def longest_substring_without_repeating_characters(text="abcabczbb"):
    """Return the longest substring without repeating characters.

    Problem: Find the longest substring with all unique characters.
    Approach: Sliding window with a set to maintain unique characters.
    Time complexity: O(n)
    Space complexity: O(k) where k is the alphabet size
    """
    if text is None:
        return ""

    seen = set()
    window_start = 0
    max_length = 0
    best_range = (0, 0)

    for window_end, char in enumerate(text):
        while char in seen:
            seen.discard(text[window_start])
            window_start += 1

        window_length = window_end - window_start + 1
        if window_length > max_length:
            max_length = window_length
            best_range = (window_start, window_end + 1)

        seen.add(char)

    return text[best_range[0]:best_range[1]]

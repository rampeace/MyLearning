"""
Reference-style examples for every tool in itertools.
Run: python sandbox/itertools_reference.py
"""
from __future__ import annotations

import sys
import itertools as it


def show(title: str, value) -> None:
    print(f"\n=== {title} ===")
    print(value)


def example_count() -> None:
    # Super-simple: pull a few values with next().
    counter = it.count(1)
    first_three = [next(counter), next(counter), next(counter)]
    show("count(1) via next()", first_three)

    # Slightly more advanced: take the first 5 values.
    first_five = list(it.islice(it.count(start=10, step=2), 5))
    show("count(start=10, step=2)", first_five)


def example_cycle() -> None:
    # Repeat a pattern forever; take the first 7 items.
    first_seven = list(it.islice(it.cycle(["A", "B", "C"]), 7))
    show("cycle(['A','B','C'])", first_seven)


def example_repeat() -> None:
    # Repeat the same value a fixed number of times.
    repeated = list(it.repeat("hi", 4))
    show("repeat('hi', 4)", repeated)


def example_accumulate() -> None:
    # Running totals (and other associative ops).
    running_sum = list(it.accumulate([1, 2, 3, 4]))
    running_product = list(it.accumulate([1, 2, 3, 4], lambda a, b: a * b))
    show("accumulate sum", running_sum)
    show("accumulate product", running_product)


def example_chain() -> None:
    chained = list(it.chain([1, 2], (3, 4), "56"))
    show("chain([1,2], (3,4), '56')", chained)


def example_chain_from_iterable() -> None:
    nested = [[1, 2], [3], [4, 5]]
    flattened = list(it.chain.from_iterable(nested))
    show("chain.from_iterable([[1,2],[3],[4,5]])", flattened)


def example_compress() -> None:
    data = list("ABCDE")
    selectors = [1, 0, 1, 0, 1]
    compressed = list(it.compress(data, selectors))
    show("compress('ABCDE', [1,0,1,0,1])", compressed)


def example_dropwhile() -> None:
    dropped = list(it.dropwhile(lambda x: x < 3, [1, 2, 3, 1, 4]))
    show("dropwhile(x < 3)", dropped)


def example_filterfalse() -> None:
    odds = list(it.filterfalse(lambda x: x % 2 == 0, range(6)))
    show("filterfalse(is_even, range(6))", odds)


def example_groupby() -> None:
    # groupby groups consecutive equal keys, so sort when needed.
    words = ["apple", "ant", "banana", "bear", "cat", "car"]
    words_sorted = sorted(words, key=lambda w: w[0])
    grouped = {k: list(g) for k, g in it.groupby(words_sorted, key=lambda w: w[0])}
    show("groupby by first letter", grouped)


def example_islice() -> None:
    sliced = list(it.islice(range(20), 2, 12, 3))
    show("islice(range(20), 2, 12, 3)", sliced)


def example_starmap() -> None:
    pairs = [(2, 5), (3, 2), (10, 3)]
    powers = list(it.starmap(pow, pairs))
    show("starmap(pow, [(2,5),(3,2),(10,3)])", powers)


def example_takewhile() -> None:
    taken = list(it.takewhile(lambda x: x < 5, [1, 4, 6, 3, 2]))
    show("takewhile(x < 5)", taken)


def example_tee() -> None:
    source = it.count(1)
    a, b = it.tee(source, 2)
    first_three_a = list(it.islice(a, 3))
    first_five_b = list(it.islice(b, 5))
    show("tee(count(1)) first 3", first_three_a)
    show("tee(count(1)) first 5", first_five_b)


def example_zip_longest() -> None:
    zipped = list(it.zip_longest([1, 2, 3], ["a", "b"], fillvalue="-"))
    show("zip_longest([1,2,3], ['a','b'], fillvalue='-')", zipped)


def example_pairwise() -> None:
    pairwise_fn = getattr(it, "pairwise", None)
    if pairwise_fn is None:
        show("pairwise", "Not available in this Python version")
        return
    pairs = list(pairwise_fn([10, 20, 30, 40]))
    show("pairwise([10,20,30,40])", pairs)


def example_batched() -> None:
    batched_fn = getattr(it, "batched", None)
    if batched_fn is None:
        show("batched", "Not available in this Python version (added in 3.12)")
        return
    batches = [tuple(batch) for batch in batched_fn(range(10), 3)]
    show("batched(range(10), 3)", batches)


def example_product() -> None:
    cart = list(it.product(["S", "M"], ["red", "blue"]))
    show("product(sizes, colors)", cart)


def example_permutations() -> None:
    perms = list(it.permutations("ABC", 2))
    show("permutations('ABC', 2)", perms)


def example_combinations() -> None:
    combs = list(it.combinations([1, 2, 3, 4], 3))
    show("combinations([1,2,3,4], 3)", combs)


def example_combinations_with_replacement() -> None:
    combs_wr = list(it.combinations_with_replacement("ABC", 2))
    show("combinations_with_replacement('ABC', 2)", combs_wr)


def main() -> None:
    print(f"Python: {sys.version.split()[0]}")
    example_count()
    example_cycle()
    example_repeat()
    example_accumulate()
    example_chain()
    example_chain_from_iterable()
    example_compress()
    example_dropwhile()
    example_filterfalse()
    example_groupby()
    example_islice()
    example_starmap()
    example_takewhile()
    example_tee()
    example_zip_longest()
    example_pairwise()
    example_batched()
    example_product()
    example_permutations()
    example_combinations()
    example_combinations_with_replacement()


if __name__ == "__main__":
    main()

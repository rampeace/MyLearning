"""Python interview cheat sheet for quick memorization."""

from collections import Counter, defaultdict, deque  # core collections
import heapq  # heap ops
import itertools  # iter tools
import math  # math ops


def cheat_sheet_examples():  # examples container
    """Examples are kept in a function so the module is compilable without side effects."""
    nums = [3, 1, 2]  # sample list
    nums2 = [4, 5, 6]  # sample list
    n = 3  # sample count
    x = 2  # sample number
    a = 1  # sample value
    b = 0  # sample value
    pairs = [("a", 1), ("b", 2)]  # sample pairs
    s = " Hello,World "  # sample string
    sep = ","  # sample separator
    lst = [3, 1, 2]  # sample list
    k = 1  # sample index
    j = 2  # sample slice end
    d = {"a": 1, "b": 2}  # sample dict
    other_dict = {"c": 3}  # sample dict
    st = {1, 2, 3}  # sample set
    other_set = {2, 3, 4}  # sample set
    stack = [1, 2, 3]  # sample stack
    dq = deque([1, 2, 3])  # sample deque
    h = [3, 1, 2]  # sample heap list

    # Builtins
    nums = []  # list init
    len(nums)  # size
    sorted(nums)  # sort
    sorted(nums, reverse=True)  # sort desc
    reversed(nums)  # reverse iterator
    enumerate(nums)  # index + value
    zip(nums, nums2)  # pair iterables
    sum(nums)  # sum
    min(nums)  # min
    max(nums)  # max
    any(nums)  # any truthy
    all(nums)  # all truthy
    range(n)  # range
    abs(x)  # absolute
    pow(x, n)  # power
    divmod(7, 3)  # quotient + remainder
    round(3.1415, 2)  # round
    list(nums)  # list
    tuple(nums)  # tuple
    set(nums)  # set
    dict(pairs)  # dict

    # Patterns
    x in nums  # membership
    x not in nums  # not membership
    a if x > 0 else b  # ternary
    [v * 2 for v in nums]  # list comp
    {k: v for k, v in pairs}  # dict comp
    {v for v in nums}  # set comp

    # Strings
    s = ""  # string init
    s.strip()  # trim both
    s.lstrip()  # trim left
    s.rstrip()  # trim right
    s.lower()  # lowercase
    s.upper()  # uppercase
    s.replace("World", "Python")  # replace
    s.split(sep)  # split
    sep.join(["a", "b"])  # join
    s.startswith(" He")  # startswith
    s.endswith("ld ")  # endswith
    s.find("lo")  # find index
    s.count("o")  # count occurrences
    s.isdigit()  # digits
    s.isalpha()  # alphabetic
    s.isalnum()  # alphanumeric
    s.isspace()  # whitespace

    # Lists
    lst = []  # list init
    lst.append(x)  # append
    lst.extend(nums2)  # extend
    lst.insert(k, x)  # insert
    lst.pop()  # pop last
    lst.pop(k)  # pop index
    lst.remove(x)  # remove value
    lst.clear()  # clear
    lst.index(x)  # index of value
    lst.count(x)  # count value
    lst.sort()  # sort
    lst.reverse()  # reverse
    lst.copy()  # shallow copy
    lst[k]  # access
    lst[:j:k]  # slice
    lst[-1]  # last element
    len(lst)  # size

    # Tuples
    t = ()  # tuple init
    t = (1, 2, 3)  # sample tuple
    t.index(x)  # tuple index
    t.count(x)  # tuple count
    t[k]  # tuple access
    t[:j:k]  # tuple slice
    len(t)  # tuple size

    # Dicts
    d = {}  # dict init
    d["c"] = 99  # set key
    d.get("a")  # get
    d.get("z", 0)  # get with default
    d.setdefault("d", 0)  # set default
    d.update(other_dict)  # update
    d.pop("a")  # pop key
    d.popitem()  # pop item
    d.keys()  # keys view
    d.values()  # values view
    d.items()  # items view
    "a" in d  # key in
    len(d)  # dict size
    d.clear()  # clear dict
    dict.fromkeys(["x", "y"], 0)  # new dict

    # Sets
    st = set()  # set init
    st.add(x)  # add
    st.update(nums)  # update
    st.remove(x)  # remove
    st.discard(x)  # discard
    st.pop()  # pop
    st.clear()  # clear
    x in st  # contains
    len(st)  # set size
    st.union(other_set)  # union
    st.intersection(other_set)  # intersection
    st.difference(other_set)  # difference
    st.symmetric_difference(other_set)  # sym diff
    st.issubset(other_set)  # subset
    st.issuperset(other_set)  # superset
    st.isdisjoint(other_set)  # disjoint

    # Counter / Defaultdict
    counter = Counter()  # counter init
    dd = defaultdict(int)  # default dict init
    Counter(nums)  # count items
    Counter(nums).most_common(1)  # top k
    dd["x"] += 1  # increment

    # Stack (list)
    stack = []  # stack init
    stack.append(x)  # push
    stack.pop()  # pop
    stack[-1]  # peek
    len(stack)  # stack size

    # Queue / Deque
    dq = deque()  # deque init
    dq.append(x)  # append right
    dq.appendleft(x)  # append left
    dq.pop()  # pop right
    dq.popleft()  # pop left
    dq.rotate(k)  # rotate
    len(dq)  # deque size

    # Heap (priority queue)
    h = []  # heap init
    heapq.heapify(h)  # heapify
    heapq.heappush(h, x)  # push heap
    heapq.heappop(h)  # pop heap
    heapq.heappushpop(h, x)  # push-pop
    heapq.heapreplace(h, x)  # replace
    heapq.nsmallest(n, nums)  # n smallest
    heapq.nlargest(n, nums)  # n largest

    # Math
    math.sqrt(x)  # sqrt
    math.ceil(3.2)  # ceil
    math.floor(3.8)  # floor
    math.gcd(12, 8)  # gcd

    # Itertools
    itertools.chain(nums, nums2)  # chain
    itertools.combinations(nums, 2)  # combinations
    itertools.permutations(nums, 2)  # permutations


if __name__ == "__main__":  # module entry
    pass  # no-op

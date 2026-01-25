
# (leet(t) code)) => Invalid because of last invalid parantheses

def is_valid(s: str):
    stack = list()

    for p in (p for p in s if p == '(' or p == ')'):
        if p == '(':
            stack.append('(')
        elif not stack or stack.pop() != '(':
            return False
    
    return not stack

print("Valid" if is_valid("((((((((x))))))))()") else "InValid")
        
    
# ()[]{}

def is_valid_all_brackets(s: str):
    stack = []
    lookup = set("[](){}")

    for c in s:
        if c not in lookup:
            continue
        elif c == '(' or c == '[' or c == '{':
            stack.append(c)
        elif not stack:
            return False
        elif c == ')' and stack.pop() != '(':
            return False
        elif c == ']' and stack.pop() != '[':
            return False
        elif c == '}' and stack.pop() != '{':
            return False
    
    return not stack

print("Valid" if is_valid("[{({[]})}]") else "InValid")
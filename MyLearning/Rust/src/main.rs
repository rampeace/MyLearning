mod bank_account;
mod inheritance_example;

use bank_account::BankAccount;
use inheritance_example::{print_employee_badge, Developer, Manager};

fn main() {
    println!("Rust ownership examples\n");

    move_ownership();
    borrow_without_taking_ownership();
    mutate_with_exclusive_borrow();
    clone_when_you_need_two_owners();
    use_sample_struct_like_a_class();
    use_traits_like_inheritance();
}

fn move_ownership() {
    let original = String::from("Rust owns this text");

    // String stores data on the heap. Assigning it to another variable moves
    // ownership instead of copying the heap data.
    let new_owner = original;

    println!("1. Move ownership");
    println!("   new_owner = {new_owner}");

    // Uncommenting this line will not compile because original was moved:
    // println!("   original = {original}");
}

fn borrow_without_taking_ownership() {
    let message = String::from("borrow me");

    println!("\n2. Borrow without taking ownership");
    print_length(&message);

    // message is still usable because print_length only borrowed it.
    println!("   message is still available = {message}");
}

fn print_length(text: &String) {
    println!("   length of '{text}' is {}", text.len());
}

fn mutate_with_exclusive_borrow() {
    let mut message = String::from("hello");

    println!("\n3. Mutable borrow");
    add_rust_suffix(&mut message);

    println!("   after mutation = {message}");
}

fn add_rust_suffix(text: &mut String) {
    text.push_str(", Rust");
}

fn clone_when_you_need_two_owners() {
    let first = String::from("clone me");

    // clone makes a real copy of the heap data, so both variables are usable.
    let second = first.clone();

    println!("\n4. Clone when you need two owners");
    println!("   first  = {first}");
    println!("   second = {second}");
}

fn use_sample_struct_like_a_class() {
    println!("\n5. Struct + impl: Rust's class-like pattern");

    let mut account = BankAccount::new(String::from("Ram"), 100.00);

    account.print_summary();

    account.deposit(50.00);
    println!("   Deposited 50.00");
    account.print_summary();

    let did_withdraw = account.withdraw(25.00);
    println!("   Withdraw 25.00 success = {did_withdraw}");
    account.print_summary();

    let did_withdraw = account.withdraw(500.00);
    println!("   Withdraw 500.00 success = {did_withdraw}");
    account.print_summary();
}

fn use_traits_like_inheritance() {
    println!("\n6. Traits: Rust's inheritance-like pattern");

    let developer = Developer::new(String::from("Anu"), String::from("Rust"));
    let manager = Manager::new(String::from("Meera"), 5);

    print_employee_badge(&developer);
    developer.write_code();

    print_employee_badge(&manager);
    manager.run_meeting();
}

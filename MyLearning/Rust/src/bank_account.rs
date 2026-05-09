pub struct BankAccount {
    owner: String,
    balance: f64,
}

impl BankAccount {
    pub fn new(owner: String, opening_balance: f64) -> BankAccount {
        BankAccount {
            owner,
            balance: opening_balance,
        }
    }

    pub fn deposit(&mut self, amount: f64) {
        self.balance += amount;
    }

    pub fn withdraw(&mut self, amount: f64) -> bool {
        if amount > self.balance {
            return false;
        }

        self.balance -= amount;
        true
    }

    pub fn print_summary(&self) {
        println!(
            "   {} has a balance of {:.2}",
            self.owner,
            self.balance
        );
    }
}

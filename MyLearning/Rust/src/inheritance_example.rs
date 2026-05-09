pub trait Employee {
    fn name(&self) -> &str;
    fn role(&self) -> &str;

    fn introduce(&self) {
        println!("   {} works as a {}", self.name(), self.role());
    }
}

pub struct Developer {
    name: String,
    favorite_language: String,
}

impl Developer {
    pub fn new(name: String, favorite_language: String) -> Developer {
        Developer {
            name,
            favorite_language,
        }
    }

    pub fn write_code(&self) {
        println!(
            "   {} writes code in {}",
            self.name,
            self.favorite_language
        );
    }
}

impl Employee for Developer {
    fn name(&self) -> &str {
        &self.name
    }

    fn role(&self) -> &str {
        "Developer"
    }
}

pub struct Manager {
    name: String,
    team_size: u32,
}

impl Manager {
    pub fn new(name: String, team_size: u32) -> Manager {
        Manager { name, team_size }
    }

    pub fn run_meeting(&self) {
        println!(
            "   {} runs a meeting for {} people",
            self.name,
            self.team_size
        );
    }
}

impl Employee for Manager {
    fn name(&self) -> &str {
        &self.name
    }

    fn role(&self) -> &str {
        "Manager"
    }
}

pub fn print_employee_badge(employee: &impl Employee) {
    employee.introduce();
}

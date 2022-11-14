use anyhow::{anyhow, Result};
use spin_sdk::{
    http::{Request, Response},
    http_component,
};

/// A simple Spin HTTP component.
#[http_component]
fn click(req: Request) -> Result<Response> 
    let address = // Insert Redis address here

    if let &http::Method::POST = req.method() {
        spin_sdk::redis::incr(&address, &"clicks").map_err(|_| anyhow!("Error querying Redis"))?;
    }

    let clicks = spin_sdk::redis::get(&address, &"clicks").map_err(|_| anyhow!("Error querying Redis"))?;

    println!("{:?}", req.headers());
    Ok(http::Response::builder()
        .status(200)
        .body(Some(clicks.into()))?)


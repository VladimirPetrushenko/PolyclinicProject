export function Header() {
    return (
        <nav className="#2196f3 blue">
            <div className="nav-wrapper">
                <a href="/" className="brand-logo">
                    WebClient for policlinic api
                </a>
                <ul id="nav-mobile" className="right hide-on-med-and-down">
                    <li>
                        <a href="/about">About</a>
                    </li>
                    <li>
                        <a href="/contacts">Contact</a>
                    </li>
                </ul>
            </div>
        </nav>
    );
}

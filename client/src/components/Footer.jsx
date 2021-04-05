import {Link} from 'react-router-dom'

export function Footer() {
    return (
        <footer className="page-footer #2196f3 blue">
            <div className="container">
                © {new Date().getFullYear()} Copyright Text
                <Link className="grey-text text-lighten-4 right" to="/">
                    Home page
                </Link>
            </div>
        </footer>
    );
}

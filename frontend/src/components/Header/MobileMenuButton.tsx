import { faBars } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import Link from 'next/link';

export default function MobileMenuButton() {
    return (
        <Link href="?menu-modal=true" className="lg:hidden">
            <FontAwesomeIcon icon={faBars} className="w-9 text-green-300" />
        </Link>
    );
}

import { faBars } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import Link from 'next/link';

interface MobileMenuButtonProps {
    href: string;
}

export default function MobileMenuButton({ href }: MobileMenuButtonProps) {
    return (
        <Link href={href} className="lg:hidden">
            <FontAwesomeIcon
                icon={faBars}
                className="text-2xl text-green-300"
            />
        </Link>
    );
}

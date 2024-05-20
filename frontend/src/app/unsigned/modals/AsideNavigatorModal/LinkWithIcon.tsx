import { IconProp } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import Link from 'next/link';

interface LinkWithIconProps {
    icon: IconProp;
    href: string;
    text: string;
}

export default function LinkWithIcon({ icon, href, text }: LinkWithIconProps) {
    return (
        <Link className="flex gap-2 items-center" href={href}>
            <FontAwesomeIcon
                className="text-green-950 w-6 h-auto"
                icon={icon}
            />
            <p className="text-green-950 font-bold text-xl">{text}</p>
        </Link>
    );
}

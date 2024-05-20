import { IconProp } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import Link from 'next/link';

interface NavigatorItemProps {
    itemTitle: string;
    itemIcon: IconProp;
    itemHref: string;
}

export default function NavigatorItem({
    itemTitle,
    itemIcon,
    itemHref
}: NavigatorItemProps) {
    return (
        <Link href={itemHref} className="flex items-center gap-2">
            <FontAwesomeIcon className="text-xl" icon={itemIcon} />
            <span className="font-semibold text-base">{itemTitle}</span>
        </Link>
    );
}

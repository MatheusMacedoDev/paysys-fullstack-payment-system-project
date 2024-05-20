import { IconProp } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import Link from 'next/link';

interface ItemProps {
    itemTitle: string;
    itemIcon: IconProp;
    itemHref: string;
}

export default function Item({ itemTitle, itemIcon, itemHref }: ItemProps) {
    return (
        <Link href={itemHref} className="flex items-center gap-2">
            <FontAwesomeIcon className="text-xl" icon={itemIcon} />
            <span className="font-semibold text-base">{itemTitle}</span>
        </Link>
    );
}

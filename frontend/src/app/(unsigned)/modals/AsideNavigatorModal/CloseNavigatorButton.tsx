import { faAngleLeft } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import Link from 'next/link';
import { usePathname } from 'next/navigation';

export default function CloseNavigatorButton() {
    const pathname = usePathname();

    return (
        <Link
            href={pathname}
            className="rounded-full w-10 h-10 bg-green-300 absolute top-[70px] right-[-14px] flex justify-center items-center"
        >
            <FontAwesomeIcon
                icon={faAngleLeft}
                className="text-green-950 w-4 h-auto"
            />
        </Link>
    );
}

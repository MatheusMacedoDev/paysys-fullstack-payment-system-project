import { ReactNode } from 'react';

interface ItemProps {
    icon?: ReactNode;
    text: string;
}

export default function Item({ icon, text }: ItemProps) {
    return (
        <li className="flex gap-2 align-middle">
            <div className="rounded-full w-5 h-5 bg-gray-800 flex align-baseline justify-center">
                {icon}
            </div>
            <h4 className="font-light text-xs text-gray-800 mt-0.5">{text}</h4>
        </li>
    );
}

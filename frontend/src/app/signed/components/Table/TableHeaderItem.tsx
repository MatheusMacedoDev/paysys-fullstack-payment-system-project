import { ReactNode } from 'react';

interface TableHeaderItemProps {
    children: ReactNode;
    colSpan?: number;
}

export default function TableHeaderItem({
    children,
    colSpan
}: TableHeaderItemProps) {
    return (
        <th className="font-semibold text-xl text-center" colSpan={colSpan}>
            {children}
        </th>
    );
}

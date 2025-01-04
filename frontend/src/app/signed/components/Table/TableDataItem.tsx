import { ReactNode } from 'react';

interface TableDataItemProps {
    children: ReactNode;
}

export default function TableDataItem({ children }: TableDataItemProps) {
    return <td className="text-xl">{children}</td>;
}

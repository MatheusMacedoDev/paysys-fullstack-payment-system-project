import { ReactNode } from 'react';

interface ItemsWrapperProps {
    children: ReactNode;
}

export default function ItemsWrapper({ children }: ItemsWrapperProps) {
    return <article className="space-y-2 mt-3">{children}</article>;
}

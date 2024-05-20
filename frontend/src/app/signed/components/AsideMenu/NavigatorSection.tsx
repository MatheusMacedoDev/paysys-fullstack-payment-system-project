import { IconProp } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { ReactNode } from 'react';

interface NavigatorSectionProps {
    sectionTitle: string;
    sectionIcon: IconProp;
    children: ReactNode;
}

export default function NavigatorSection({
    sectionTitle,
    sectionIcon,
    children
}: NavigatorSectionProps) {
    return (
        <section className="text-green-300 space-y-8">
            <div className="flex items-center gap-2">
                <FontAwesomeIcon className="text-2xl" icon={sectionIcon} />
                <span className="font-extrabold text-xl">{sectionTitle}</span>
            </div>
            <div className="ml-5 space-y-5">{children}</div>
        </section>
    );
}

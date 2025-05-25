//const activate = (id) => fetch(`/home/activate/${id}`, { method: "POST" })
//    .catch(err => console.error("Activate:", err))

//const deactivate = (id) => fetch(`/home/deactivate/${id}`, { method: "POST" })
//    .catch(err => console.error("Deactivate:", err))

//const delete_item = (id) => fetch(`/home/delete/${id}`, { method: "POST" })
//    .catch(err => console.error("Delete:", err))

//const recycle = (id) => fetch(`/home/recycle/${id}`, { method: "POST" })
//    .catch(err => console.error("Recycle:", err))

//const publish = (id) => fetch(`/home/publish/${id}`, { method: "POST" })
//    .then(res => console.log("Publish Date:", res))
//    .catch(err => console.error("Publish:", err))

//const unpublish = (id) => fetch(`/home/unpublish/${id}`, { method: "POST" })
//    .catch(err => console.error("Unpublish:", err))

const toggleActivation = (id) => {
    fetch(`/home/toggleactivation/${id}`, { method: "POST" })
        .then(res => res.text())
        .then(data => {
            if (data == 'True') {
                document.querySelector(`.article-item[key="${id}"] .btn-activation`).innerHTML = `<i class="fa-regular fa-square-check text-success fa-2x" title="Deactivate"></i>`
            } else {
                document.querySelector(`.article-item[key="${id}"] .btn-activation`).innerHTML = `<i class="fa-regular fa-square text-secondary fa-2x" title="Activate"></i>`
            }
        })
        .catch(err => console.error("Activation Error:", err))
}

const toggleRecycling = (id) => {
    fetch(`/home/togglerecycling/${id}`, { method: "POST" })
        .then(res => res.text())
        .then(data => {
            if (data == 'True') {
                document.querySelector(`.article-item[key="${id}"] .btn-recycling`).innerHTML = `<i class="fa-solid fa-recycle fa-2x text-info" title="Recycle"></i>`
            } else {
                document.querySelector(`.article-item[key="${id}"] .btn-recycling`).innerHTML = `<i class="fa-solid fa-trash-can fa-2x text-danger" title="Delete"></i>`
            }
        })
        .catch(err => console.error("Recycling Error:", err))
}

const togglePublishing = (id) => {
    fetch(`/home/togglepublishing/${id}`, { method: "POST" })
        .then(res => res.text())
        .then(data => {
            if (data) {
                const publish_date = new Date(data)
                document.querySelector(`.article-item[key="${id}"] .btn-publishing`).innerHTML = `<span>${publish_date.toLocaleDateString("tr-TR")}</span>`
            } else {
                document.querySelector(`.article-item[key="${id}"] .btn-publishing`).innerHTML = `<span class="text-primary"><i class="fa-solid fa-thumbtack"></i> Publish</span>`
            }
        })
        .catch(err => console.error("Publishing Error:", err))
}


const article_items = document.getElementsByClassName('article-item')

Array.from(article_items).forEach(item => {
    const id = item.getAttribute('key')

    item.querySelector('.btn-activation').addEventListener('click', () => toggleActivation(id))
    item.querySelector('.btn-recycling').addEventListener('click', () => toggleRecycling(id))
    item.querySelector('.btn-publishing').addEventListener('click', () => togglePublishing(id))

    //if (item.querySelector('.activate')) {
    //    item.querySelector('.activate').addEventListener("click", () => {
    //        activate(id);
    //        location.reload(true);
    //    })
    //}

    //if (item.querySelector('.deactivate')) {
    //    item.querySelector('.deactivate').addEventListener("click", () => {
    //        deactivate(id);
    //        location.reload(true);
    //    })
    //}

    //if (item.querySelector('.delete')) {
    //    item.querySelector('.delete').addEventListener("click", () => {
    //        delete_item(id);
    //        location.reload(true);
    //    })
    //}

    //if (item.querySelector('.recycle')) {
    //    item.querySelector('.recycle').addEventListener("click", () => {
    //        recycle(id);
    //        location.reload(true);
    //    })
    //}

    //if (item.querySelector('.publish')) {
    //    item.querySelector('.publish').addEventListener("click", () => {
    //        publish(id);
    //        location.reload(true);
    //    })
    //}

    //if (item.querySelector('.unpublish')) {
    //    item.querySelector('.unpublish').addEventListener("click", () => {
    //        unpublish(id);
    //        location.reload(true);
    //    })
    //}
})